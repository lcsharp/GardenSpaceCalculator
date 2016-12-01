using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{

    static List<Vegetable> vegetables = new List<Vegetable> ( ); // Keeps a persistant list of vegetables throughout the life of the program
    Vegetable tempVegetable = new Vegetable();                   // A vegetable object used to gain access to the 'Vegetable' class

    /// <summary>
    /// Runs when the app first loads and initializes the vegetables
    /// list. Also calls the method that creates the table of vegetables
    /// that the user sees and initializes that table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if(this.vegetableListBox.Items.Count == 0)
        {
            if(vegetables.Count == 0)
            {
                vegetables = tempVegetable.initializeVegetableList (vegetables);
            }           
            for(int i = 0; i < vegetables.Count; i++)
            {
                tempVegetable.manageVegetableListBox (vegetables, this.vegetableListBox);
            }
        }
    }

    /// <summary>
    /// Manages the lists and summation updates that happen when a vegetable
    /// is added to the list. This method is responsible for calling other
    /// methods that calculate data that it then uses for maintanence and 
    /// display purposes.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void addButton_Click (object sender, EventArgs e)
    {
        int total = 0;
        tempVegetable.manageVegetableList (vegetables, this.vegetableList.SelectedValue, int.Parse (this.quantityInput.Text));
        tempVegetable.manageVegetableListBox (vegetables, this.vegetableListBox);
        total += tempVegetable.handleBeansAndSquash (vegetables);
        total = tempVegetable.addValues (vegetables, total);
        this.total.Text = total.ToString ( ) + " sqft. are needed for this garden.";
    }

    /// <summary>
    /// Resets the entire form back to its original state when the 'Reset" 
    /// button is clicked. This also clears all lists and reinitializes the
    /// table of vegetables that is displayed to the user
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void clearButton_Click (object sender, EventArgs e)
    {
        vegetables.Clear ( );
        vegetables = tempVegetable.initializeVegetableList (vegetables);
        for (int i = 0; i < vegetables.Count; i++)
        {
            tempVegetable.manageVegetableListBox (vegetables, this.vegetableListBox);
        }
        this.vegetableList.SelectedIndex = 0;
        this.quantityInput.Text = "1";
        this.total.Text = "0 sqft. are needed for this garden.";
    }
}