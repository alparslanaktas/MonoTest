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

    void OnValidate()
    {
        if (nameText != null)
        {
            nameText.text = name;
        }
    }
}
