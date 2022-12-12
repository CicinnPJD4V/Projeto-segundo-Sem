using UnityEngine;



[CreateAssetMenu(fileName = "EnemyData", menuName = "Assets/Enemy", order = 0)]
public class EnamyDataSO : ScriptableObject
{
    
    public float moveSpeed;

    public int maxHealthPoints;

    public GameObject enemyMesh;
    
    
    
    public float followDistance; //x
    
    public float returnDistance; //z
    
    public float attackDistance; //y
    
    public float geviUpDistance; //w
    
    
    
    
    
    
    
    
    
}
