using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeToEnd;
    public GameObject bulletPrefab;
    
    private List<GameObject> _listOfBullets;
    private float _currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _listOfBullets = new List<GameObject>();
        for(int i = 0; i < timeToEnd/10; i++)
        {
            Debug.Log(i);
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(i * .1F, 0, 0), Quaternion.Euler(0, 0, 90));
            _listOfBullets.Add(bullet);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _currentTime += Time.fixedDeltaTime;
        if(((timeToEnd - _currentTime) / 10)+1 < _listOfBullets.Count)
        {
            Destroy(_listOfBullets[_listOfBullets.Count - 1]);
            _listOfBullets.Remove(_listOfBullets[_listOfBullets.Count - 1]);
        }
        //Debug.Log(timeToEnd - _currentTime);
    }
}
