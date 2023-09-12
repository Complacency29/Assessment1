using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/Weapons")]
public class Weapon : ScriptableObject
{
    [SerializeField] string weaponName = "Enter Name";
    [SerializeField] Vector2Int weaponDamage = new Vector2Int(1,6);
    [SerializeField] int maxDurability = 10;

    public string WeaponName { get { return weaponName; } }
    public Vector2Int WeaponDamage { get { return weaponDamage; } }
    public int MaxDurability { get {  return maxDurability; } }
}
