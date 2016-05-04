using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveLight : MonoBehaviour 
{
	private Vector3 speed;
	private float moveLimit;
	private Vector3 lightStartPoint;
	
	public GameObject[] projectors;
	
	
	// Use this for initialization
	void Start () 
	{
		speed = new Vector3(0.05f, 0.0f, 0.05f);
		moveLimit = 0.5f;
		lightStartPoint = new Vector3(this.transform.position.x,
										this.transform.position.y,
										this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
    { 
        UpdatePlayer(); 
    }
		
	/// <summary>
	/// Call a method to move the player in 9 directions depending on keyDown.
	/// </summary>
	private void UpdatePlayer()
	{	
		if(Input.GetKey(KeyCode.LeftArrow))
		{
            if (this.transform.localPosition.x > lightStartPoint.x - moveLimit)
            {
                Move(-speed.x, 0);

                MoveProjector(projectors[0], -0.5f, 0, 1);
                MoveProjector(projectors[1], -0.5f, 0, 0.5f);
                MoveProjector(projectors[2], 0, 0.5f, 0);
                MoveProjector(projectors[3], 0, -0.5f, -1);
                MoveProjector(projectors[4], 0, -0.5f, 0);
            }
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
            if (this.transform.localPosition.x < lightStartPoint.x + moveLimit)
            {
                Move(speed.x, 0);
                MoveProjector(projectors[0], 0.5f, 0, -1);
                MoveProjector(projectors[1], 0.5f, 0, -0.5f);
                MoveProjector(projectors[2], 0, -0.5f, 0);
                MoveProjector(projectors[3], 0, 0.5f, 1);
                MoveProjector(projectors[4], 0, 0.5f, 0);
            }
		}
		else if(Input.GetKey(KeyCode.UpArrow))
		{
            if (this.transform.localPosition.z < lightStartPoint.z + moveLimit)
            {
                Move(0, speed.z);
                MoveProjector(projectors[0], 0, 1, 0);
                MoveProjector(projectors[1], 0, 1, 0);
                MoveProjector(projectors[2], 0.5f, 0, 1);
                MoveProjector(projectors[3], -0.5f, 0, 0);
                MoveProjector(projectors[4], 0.5f, 0, 1);
            }
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
            if (this.transform.localPosition.z > lightStartPoint.z - moveLimit)
            {
                Move(0, -speed.z);
                MoveProjector(projectors[0], 0, -1, 0);
                MoveProjector(projectors[1], 0, -1, 0);
                MoveProjector(projectors[2], -0.5f, 0, -1);
                MoveProjector(projectors[3], 0.5f, 0, 0);
                MoveProjector(projectors[4], -0.5f, 0, -1);
            }
		}		
	}
	
	/// <summary>
	/// Translate and rotate the light.
	/// </summary>
	/// <param name='speedX'>
	/// Speed x.
	/// </param>
	/// <param name='speedY'>
	/// Speed y.
	/// </param>
	private void Move(float speedX, float speedZ)
	{
		this.transform.localPosition = new Vector3(this.transform.localPosition.x + speedX,
														this.transform.localPosition.y,
														this.transform.localPosition.z + speedZ);
	}

    private void MoveProjector(GameObject projector, float rotationX, float rotationY, float field)
    {
        projector.transform.localEulerAngles = new Vector3(projector.transform.localEulerAngles.x + rotationX,
                                                           projector.transform.localEulerAngles.y + rotationY,
                                                           projector.transform.localEulerAngles.z);

        projector.GetComponent<Projector>().fieldOfView += field;
    }
}