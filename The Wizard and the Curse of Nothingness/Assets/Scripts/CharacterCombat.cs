using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Author: Mohammed Alghamdi
Popuse: this file encapsulates all the code related to the hero fighting and 
  defending by a shield.
 */
public class CharacterCombat : MonoBehaviour
{

    public bool isShielded;
    public bool isShieldedInitial; // retrieved from the memory
    public bool isAttacking; // close range attacking
    public bool isAttackingInitial; // retrieved from the memory
    public bool isShooting; // far range attacking
    public bool isShootingInitial; // retrieved from the memory

    // Start is called before the first frame update
    void Start()
    {
        isShieldedInitial = true;
        isShielded = false;
        isAttackingInitial = true;
        isAttacking = false;
        isShootingInitial = true;
        isShooting = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            attack();
        if(Input.GetKey(KeyCode.Mouse1))
            shoot();
        if(Input.GetKey(KeyCode.Space))
            shield();
    }


    // this method establishes the event of attack(close range)
    private void attack() {
        //TODO animation
    }

    // this method establishes the event of sheild
    private void shield() {
        //TODO animation
    }

    // this method establishes the event of shooting(far range attack)
    private void shoot() {
        
    }
}
