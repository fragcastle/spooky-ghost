using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{
	public GameObject Target;
	public bool LockX;
	public bool LockY;
	public bool LockZ; 
    public Vector2 Offset;

    void Start()
    {
    }

    void Update()
    {
		if (!Target)
            return;

		var position = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
		
		if (LockX) position.x = transform.position.x;
		if (LockY) position.y = transform.position.y;
		if (LockZ) position.z = transform.position.z;
		
		position.x += Offset.x;
		position.y += Offset.y;
		
		transform.position = position;
    }
}
