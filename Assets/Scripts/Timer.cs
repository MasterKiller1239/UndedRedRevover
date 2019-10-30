using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeToEnd;
    public GameObject bulletPrefab;
    
    private List<GameObject> _listOfBullets;
    private float _currentTime;
    

    void Start()
    {
        float trans = 0;
        _listOfBullets = new List<GameObject>();
        for(int i = 0; i < timeToEnd/10; i++)
        {
            if(i % 6 != 0)
            {
                trans += .1f;
            }  
            else
            {
                trans += .2f;
            }
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + trans, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 90));
            _listOfBullets.Add(bullet);
        }
    }


    void FixedUpdate()
    {
        _currentTime += Time.fixedDeltaTime;
        if(((timeToEnd - _currentTime) / 10)+1 > _listOfBullets.Count){
            float trans = 0;
            while(((timeToEnd - _currentTime) / 10)+1 > _listOfBullets.Count){
                if(_listOfBullets.Count % 6 != 0)
                {
                    trans = .1f;
                }
                else
                {
                    trans = .2f;
                }
                GameObject bullet = Instantiate(bulletPrefab,
                new Vector3(_listOfBullets[_listOfBullets.Count-1].transform.position.x + trans,
                    _listOfBullets[_listOfBullets.Count-1].transform.position.y,
                    _listOfBullets[_listOfBullets.Count-1].transform.position.z),
                    Quaternion.Euler(0, 0, 90));
                    _listOfBullets.Add(bullet);
                }
                
        }
        if(((timeToEnd - _currentTime) / 10)+1 < _listOfBullets.Count)
        {
            Destroy(_listOfBullets[_listOfBullets.Count - 1]);
            _listOfBullets.Remove(_listOfBullets[_listOfBullets.Count - 1]);
        }
        //Debug.Log(timeToEnd - _currentTime);
    }
}
