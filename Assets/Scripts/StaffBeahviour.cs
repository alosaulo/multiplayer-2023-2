using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffBeahviour : MonoBehaviour
{

    [SerializeField]
    GameObject magicPrefab;

    [SerializeField]
    Transform OriginAtk;

    public MagicType type;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoAtack() 
    {
        Instantiate(magicPrefab, OriginAtk.transform.position, OriginAtk.rotation);
        Debug.Log($"damage:{damage}|type:{type}");
    }

}
