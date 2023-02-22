using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDNF : MonoBehaviour{

    public float speed;

    //캐릭터의 움직임
    private Vector3 vector; // x, y ,z

    public int walkCount; // 픽셀 단위로 이동
    public int currentWalkCount; // 20 일때 반복문 탈출

  private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator MoveCoroutine()
    {
                   
            //백터에 저장
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
        


        while(currentWalkCount < walkCount)
        {

                   //1 이면 우 -1 좌 
            if(vector.x !=0)
            {
                transform.Translate(vector.x * speed, 0, 0);
            }else if(vector.y !=0)
            {
                 transform.Translate(0 ,vector.y * speed, 0);
            }
        
            currentWalkCount ++;
             yield return new WaitForSeconds(0.01f);
        }
        currentWalkCount = 0;

         canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
      // 좌우 상하 반향 눌리면 1 안눌리면 -1 리턴
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
            
            canMove = false;
        StartCoroutine(MoveCoroutine());
        }
    }
        }
  
}
