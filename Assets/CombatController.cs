using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] int defaultAC = 10;

    [InspectorLabel("Combatant 1")]
    [SerializeField] Weapon combatant1Weapon;
    [SerializeField] Armor combatant1Armor;
    [SerializeField] int combatant1AttackBonus;
    [SerializeField] int combatant1Health = 20;
    int combatant1AC = 10;

    [InspectorLabel("Combatant 2")]
    [SerializeField] Weapon combatant2Weapon;
    [SerializeField] Armor combatant2Armor;
    [SerializeField] int combatant2AttackBonus;
    [SerializeField] int combatant2Health = 20;
    int combatant2AC = 10;


    int turnIndex = 0;

    private void Start()
    {
        combatant1AC += combatant1Armor.AcBonus;
        combatant2AC += combatant2Armor.AcBonus;
    }
    public void RunCombatRound()
    {
        if(turnIndex == 0) //combatant1 attacking combatant2
        {
            //roll to hit (1d20 + attack bonus vs AC
            int hitRoll = RollToHit(combatant1AttackBonus);
            Debug.Log("Combatant 1 attacked combatant 2 using a " + combatant1Weapon.WeaponName + ", rolling a " + hitRoll);

            //if hit, roll damage, remove damage resistance, apply damage to health;
            if(hitRoll > combatant1AC)
            {
                int damage = RollDamage(combatant1Weapon.WeaponDamage.x, combatant1Weapon.WeaponDamage.y);
                damage -= combatant2Armor.DamageResistance;
                combatant2Health -= damage;
                Debug.Log("Combatant 1 hit combatant 2, dealing " + damage + " damage.");

                if(combatant2Health <= 0)
                {
                    Debug.Log("Combatant 2 is dead.");
                }
            }
            else
            {
                Debug.Log("Combatant 1 missed with their attack!");
            }

            Debug.Log("Combatant 1 turn over.");
            turnIndex = 1;
        }
        else //combatant2 attacking combatant1
        {
            //roll to hit (1d20 + attack bonus vs AC
            int hitRoll = RollToHit(combatant2AttackBonus);
            Debug.Log("Combatant 2 attacked combatant 1 using a " + combatant1Weapon.WeaponName + ", rolling a " + hitRoll);

            //if hit, roll damage, remove damage resistance, apply damage to health;
            if (hitRoll > combatant1AC)
            {
                int damage = RollDamage(combatant2Weapon.WeaponDamage.x, combatant2Weapon.WeaponDamage.y);
                damage -= combatant1Armor.DamageResistance;
                combatant1Health -= damage;
                Debug.Log("Combatant 2 hit combatant 1, dealing " + damage + " damage.");

                if (combatant1Health <= 0)
                {
                    Debug.Log("Combatant 1 is dead.");
                }
            }
            else
            {
                Debug.Log("Combatant 2 missed with their attack!");
            }

            Debug.Log("Combatant 2 turn over.");

            turnIndex = 0;
        }
    }

    private int RollDamage(int _numDice, int _maxDamage)
    {
        int damage = 0;
        for (int i = 0; i < _numDice; i++)
        {
            damage += Random.Range(1, _maxDamage + 1);
        }
        return damage;
    }

    private int RollToHit(int _attackBonus)
    {
        int attackRoll = Random.Range(1, 21);
        attackRoll += _attackBonus;
        return attackRoll;
    }
}
