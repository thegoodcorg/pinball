using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float RestPosition = 0f;
    public float PressedPosition = 45f;
    public float HitStrength = 10000f;
    public float FlipperDamper = 150f;
    HingeJoint joint;

    public string InputName;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
        joint.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
            JointSpring spring = new JointSpring();
            spring.spring = HitStrength;
            spring.damper = FlipperDamper;

        if (Input.GetAxis(InputName) == 1)
        {
            spring.targetPosition = PressedPosition;
        }
        else
        {
            spring.targetPosition = RestPosition;
        }
        joint.spring = spring;
        joint.useLimits = true;
    }
}
