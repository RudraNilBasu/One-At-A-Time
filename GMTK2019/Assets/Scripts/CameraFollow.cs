using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform player_1, player_2;
    Transform target;

    float multiplier = 1.0f;

	// Use this for initialization
	void FollowTarget (Vector2 target) {
        transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, target.x, multiplier * Time.deltaTime),
                Mathf.Lerp(transform.position.y, target.y, multiplier * Time.deltaTime), -10);
        // transform.position = new Vector3(
                // Mathf.Lerp(transform.position.x, target.position.x, multiplier * Time.deltaTime),
                // Mathf.Lerp(transform.position.y, target.position.y, multiplier * Time.deltaTime), -10);
	}
	
	// Update is called once per frame
	void Update () {
        // Debug.Log("Distance: " + (player_2.position.x - player_1.position.x)); // 9.73
        // depending on the position of the two players, we will update the target
        Vector2 p1_camera_pos = Camera.main.WorldToViewportPoint(player_1.position);
        Vector2 p2_camera_pos = Camera.main.WorldToViewportPoint(player_2.position);
        if (p1_camera_pos.x <= 0.1f) {
            target = player_1;
            // FollowTarget(p1_camera_pos);
        } else if (p2_camera_pos.x >= 0.9f) {
            target = player_2;
            // FollowTarget(p2_camera_pos);
        } else if(p1_camera_pos.y <= 0.3f || p1_camera_pos.y >= 0.9f) {
            target = player_1;
        } else {
            return;
        }
        transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, target.position.x, multiplier * Time.deltaTime),
                Mathf.Lerp(transform.position.y, target.position.y, multiplier * Time.deltaTime), -10);
	}
}
