using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/Armor")]
public class Armor : ScriptableObject
{
    [SerializeField] string armorName;
    [SerializeField] int damageResistance;
    [SerializeField] int acBonus = 1;

    public string ArmorName { get { return armorName; } }
    public int DamageResistance { get { return damageResistance; } }
    public int AcBonus { get { return acBonus; } }
}
