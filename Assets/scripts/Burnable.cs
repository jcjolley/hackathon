using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnable : MonoBehaviour
{
    public int burnThreshhold = 3;
    bool burning = false;
    float burningCount = 0;
    public void burn()
    {
        print("IT'S BURRRRRNING!");
        this.burning = true;
    }

    void Update()
    {
        if (this.burning)
        {
            this.burningCount += 1 * Time.deltaTime;
            print("Burning Couint:" + this.burningCount);
        }

        if (this.burningCount > burnThreshhold)
        {
            Destroy(gameObject);
        }
    }
}
