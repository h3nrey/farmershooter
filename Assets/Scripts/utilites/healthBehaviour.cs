using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBehaviour : MonoBehaviour
{
    [SerializeField] int life = 100, currentLife;
    [SerializeField] bool isPlayer;


    //externals
    [SerializeField] changeSceneBehaviour _changeScene;
    // Start is called before the first frame update
    void Awake()
    {
        currentLife = life;
        _changeScene = this.gameObject.GetComponent<changeSceneBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int damage) {
        print("me feri");
        currentLife -= damage;

        if(currentLife <=0) {
            die();
        }
    }

    public void die() {
        Destroy(this.gameObject);
        if(isPlayer){
            _changeScene.callScene("gameOverScene");
        }
    }
}
