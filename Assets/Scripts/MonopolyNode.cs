using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;

public enum MonopolyNodeType
{
    Property,
    Utility,
    Railroad,
    Tax,
    Chance,
    CommunityChest,
    Go,
    Jail,
    FreeParking,
    GoToJail
}

public class MonopolyNode : MonoBehaviour
{
    public MonopolyNodeType monopolyNodeType;
    [Header("Name")]
    [SerializeField] internal new string name;
    [SerializeField] TMP_Text nameText;
    [Header("Property Price")]
    public int price;
    [SerializeField] TMP_Text priceText;
    [Header("Property Rent")]
    [SerializeField] bool calculateRentAuto;
    [SerializeField] int currentRent;
    [SerializeField] internal int baseRent;
    [SerializeField] internal int[] rentWithHouses;
    [Header("Property Mortgage")]
    [SerializeField] GameObject mortgageImage;
    [SerializeField] GameObject propertyImage;
    [SerializeField] bool isMortgaged;
    [SerializeField] int mortgageValue;
    [Header("Property Owner")]
    [SerializeField] GameObject ownerBar;
    [SerializeField] TMP_Text ownerText;



    void OnValidate()
    {
        if (nameText != null)
        {
            nameText.text = name;
        }

        //CALCULATION
        if (calculateRentAuto)
        {
            if (baseRent > 0)
            {
                price = 3 * (baseRent * 10);
                //MORTGAGE PRICE
                rentWithHouses = new int[]
                {
                    baseRent * 5,
                    baseRent * 5 * 3,
                    baseRent * 5 * 9,
                    baseRent * 5 * 16,
                    baseRent * 5 * 25,
                };
            }
        }
        if(monopolyNodeType == MonopolyNodeType.Utility)
        {
            mortgageValue = price / 2;
        }

        if (monopolyNodeType == MonopolyNodeType.Railroad)
        {
            mortgageValue = price / 2;
        }

        if (priceText != null)
        {
            priceText.text = "$ " + price;
        }
        //UPDATE THE OWNER
    }

    //MORTGAGE CONTENT
    public int MortgageProperty()
    {
        isMortgaged = true;
        mortgageImage.SetActive(true);
        propertyImage.SetActive(false);
        return mortgageValue;
    }

    public void unMortgageProperty()
    {
        isMortgaged = false;
        mortgageImage.SetActive(false);
        propertyImage.SetActive(true);
    }

    public bool IsMortgaged => isMortgaged;
    public int MortgageValue => mortgageValue;
    //UPDATE OWNER
    public void OnOwnerUpdated()
    {
        if (ownerBar != null)
        {
            if (ownerText.text != "")
            {
                ownerBar.SetActive(true);
                //ownerText.text = owner.name;
            }
            else
            {
                ownerBar.SetActive(false);
                ownerText.text = "";
            }
        }
    }

}
