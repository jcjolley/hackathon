using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnable : MonoBehaviour {

    
    public void burn()
    {
        print("IT'S BURRRRRNING!");
        Destroy(gameObject);
    }
}
