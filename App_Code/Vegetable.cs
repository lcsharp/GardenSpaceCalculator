using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

/// <summary>
/// Creates Vegetable objects and manages behaviors
/// and lists associated with various functions we
/// want to use Vegetables with
/// </summary>
public class Vegetable
{
    //Class attrubutes
    String name; // name of vegetable
    int value;   // represents the amount of space the vegetable requires

    // Useful constants
    const String peppers = "Peppers";
    const String tomatoes = "Tomatoes";
    const String beans = "Beans";
    const String squash = "Squash";

    /// <summary>
    /// No-arg constructor for the Vegetable class
    /// </summary>
    public Vegetable ( )
    {
        this.name = "";
        this.value = 0;
    }

    /// <summary>
    /// Parameterized constructor that accepts a name and value for 
    /// the Vegetable object being created.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public Vegetable (String name, int value)
    {
        setName (name);
        setValue (value);
    }

    /// <summary>
    /// Setter for the name property
    /// </summary>
    /// <param name="name"></param>
    public void setName (String name)
    {
        this.name = name;
    }

    /// <summary>
    /// Setter for the value property
    /// </summary>
    /// <param name="value"></param>
    public void setValue (int value)
    {
        this.value = value;
    }

    /// <summary>
    /// Getter for the name property
    /// </summary>
    /// <returns></returns>
    public string getName ()
    {
        return this.name;
    }

    /// <summary>
    /// Getter for the value property
    /// </summary>
    /// <returns></returns>
    public int getValue ()
    {
        return this.value;
    }

    /// <summary>
    /// Accepts a list of vegetables, adds one of each type of vegetable to that
    /// list, and returns the list. In this program this method is used to 
    /// initialize the list when the program first starts or a user hits the
    /// 'Reset' button. Any future vegetables should be added to this method so
    /// that they will exist in the 'vegetables' list.
    /// </summary>
    /// <param name="vegetables"></param>
    /// <returns></returns>
    public List<Vegetable> initializeVegetableList (List<Vegetable> vegetables)
    {
        vegetables.Add (new Vegetable (peppers, 0));
        vegetables.Add (new Vegetable (tomatoes, 0));
        vegetables.Add (new Vegetable (beans, 0));
        vegetables.Add (new Vegetable (squash, 0));
        return vegetables;
    }

    /// <summary>
    /// Called when a vegetable is added to the list. This function finds that 
    /// vegetable in the list and increments its number by the amount chosen by
    /// the user.
    /// </summary>
    /// <param name="vegetables"></param>
    /// <param name="selectedVegetable"></param>
    /// <param name="inputQuantity"></param>
    public void manageVegetableList (List<Vegetable> vegetables, String selectedVegetable, int inputQuantity)
    {
        for(int i = 0; i < vegetables.Count; i++)
        {
            if (vegetables[i].name.Equals (selectedVegetable))
            {
                int temp = vegetables[i].value;
                vegetables[i].setValue (inputQuantity + temp);
                break;
            }
        }
    }

    /// <summary>
    /// Called when the program starts, when a vegetable is added to the list, 
    /// and when the 'Reset' button is clicked. This function manages the list
    /// of vegetables that allows the user to keep track of what they have chosen.
    /// </summary>
    /// <param name="vegetables"></param>
    /// <param name="vegetableListBox"></param>
    public void manageVegetableListBox (List<Vegetable> vegetables, ListBox vegetableListBox)
    {
        String nameSection; // will contain the name + the '-' characters
        int quantity;       // will contain the quantity that the user specified

        // clears the existing list and creates a new list for displaying to the user
        vegetableListBox.Items.Clear ( ); 
        for (int i = 0; i < vegetables.Count; i++)
        {
            nameSection = createNameSectionString (vegetables[i].name);
            quantity = vegetables[i].value;
            vegetableListBox.Items.Add (nameSection + " " + quantity);
        }
    }

    /// <summary>
    /// This method is a crude attempt to control the appearance of the vegetable 
    /// list, which is presented to the user. It's purpose is to add '-' marks to
    /// the vegetable name for display purposes. This should be replaced with some
    /// custom css that handles formatting the box.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    protected String createNameSectionString (String name)
    {
        if (name.Equals (peppers))
        {
            name += " -------- ";
        }
        else if (name.Equals (tomatoes))
        {
            name += " ------ ";
        }
        else if (name.Equals (beans))
        {
            name += " ----------- ";
        }
        else if (name.Equals (squash))
        {
            name += " --------- ";
        }
        return name;
    }

    /// <summary>
    /// This is a special condition that allows beans and squash to use the same 
    /// space in the garden. As such the easiest way to find the amount needed for
    /// both is to check which of the two requires the most space and then that 
    /// space requirement will be sufficient for both vegetables.
    /// 
    /// The method goes through the entire list of vegetables and searches for beans
    /// or squash. It tracks the actual total space requirement for each and then 
    /// returns the number for the vegetable that requires larger amount of space. 
    /// </summary>
    /// <param name="vegetables"></param>
    /// <returns></returns>
    public int handleBeansAndSquash (List<Vegetable> vegetables)
    {
        Vegetable currentVegetable;
        int beansSpace = 0;
        int squashSpace = 0;
        for(int i = 0; i < vegetables.Count; i++)
        {
            currentVegetable = vegetables[i];
            if(currentVegetable.name.Equals(beans))
            {
                beansSpace = currentVegetable.value * currentVegetable.getActualValue (currentVegetable.name);
            }
            if (vegetables[i].getName ( ).Equals (squash))
            {
                squashSpace = currentVegetable.value * currentVegetable.getActualValue (currentVegetable.name);
            }
        }
        return beansSpace >= squashSpace ? beansSpace : squashSpace;
    }

    /// <summary>
    /// Since beans and squash were calculated in a special method this method
    /// calculates and returns the space requirements for all other vegetables
    /// and returns that amount. 
    /// </summary>
    /// <param name="vegetables"></param>
    /// <param name="total"></param>
    /// <returns></returns>
    public int addValues (List<Vegetable> vegetables, int total)
    {
        for (int i = 0; i < vegetables.Count; i++)
        {
            if (!vegetables[i].name.Equals (beans) && !vegetables[i].name.Equals (squash))
            {
                total += getActualValue (vegetables[i].name) * vegetables[i].value;
            }
        }
        return total;
    }

    /// <summary>
    /// Returns the actual space requirement for the vegetable that is passed
    /// into the method.
    /// </summary>
    /// <param name="selectedVegetable"></param>
    /// <returns></returns>
    protected int getActualValue (String selectedVegetable)
    {
        int value = 0;

        if (selectedVegetable.Equals (beans) || selectedVegetable.Equals (squash))
        {
            value = 3;
        }
        else if (selectedVegetable.Equals (tomatoes))
        {
            value = 2;
        }
        else if (selectedVegetable.Equals (peppers))
        {
            value = 1;
        }
        return value;
    }
}