// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.U2D;


// [ExecuteInEditMode]
// public class EnvironmentGen : MonoBehaviour
// {
//     [SerializeField] private SpriteShapeController ssc ;
//     [SerializeField] private int levelLength =10;
//     [SerializeField] private float xM =2f;
//     [SerializeField] private float yM =2f;
//     [SerializeField] private float curve =0.5f;
//     [SerializeField] private float noise =1.5f;
//     [SerializeField] private float bottom =10f;

//     private Vector3 lastpos;
//     private void OnValidate() {
//         ssc.spline.Clear();
//         for (int i = 0; i < levelLength; i++)
//         {
//             lastpos = transform.position + new Vector3(i*xM , yM*Mathf.PerlinNoise(0,i*noise));
//             ssc.spline.InsertPointAt(i , lastpos);
        
//             if (i != 0 && i!= levelLength -1)
//             {
//                 ssc.spline.SetTangentMode(i , ShapeTangentMode.Continuous);
//                 ssc.spline.SetLeftTangent(i , Vector3.left * xM*curve);
//                 ssc.spline.SetRightTangent(i , Vector3.right * xM*curve);
//             }
                
//         }
//             ssc.spline.InsertPointAt(levelLength , new Vector3(lastpos.x , transform.position.y - bottom));
//             ssc.spline.InsertPointAt(levelLength +1 , new Vector3(transform.position.x , transform.position.y - bottom));
//         }
//     }

using UnityEngine;
using UnityEngine.U2D;
[ExecuteInEditMode]
public class EnvironmentGen : MonoBehaviour
{
    public SpriteShapeController shape;
    public int scale = 5000;
    public int numofPoints = 100;

    private void Start()
    {
        float distanceBwtnpoints = (float)scale / (float)numofPoints;
        shape = GetComponent<SpriteShapeController>();
        shape.spline.SetPosition(2, shape.spline.GetPosition(2) + Vector3.right * scale);
        shape.spline.SetPosition(3, shape.spline.GetPosition(3) + Vector3.right * scale);

        for (int i = 0; i < 150; i++)
        {
            float xPos = shape.spline.GetPosition(i + 1).x + distanceBwtnpoints;
            shape.spline.InsertPointAt(i + 2, new Vector3(xPos, Mathf.PerlinNoise(i * Random.Range(5.0f, 8.0f), 0)));
        }

        for (int i = 2; i < 152; i++)
        {
            shape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            shape.spline.SetLeftTangent(i, new Vector3(-2, 0, 0));
            shape.spline.SetRightTangent(i, new Vector3(2, 0, 0));
        }
    }
}

