using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordListTextScript : MonoBehaviour
{
    public Text RecordListText;

    private void Update()
    {
        RecordListText.text = "Killed monsters: " + GameControllerScript.maxKilledEnemies.ToString();
    }




}
