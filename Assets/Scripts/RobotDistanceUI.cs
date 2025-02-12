using UnityEngine;
using UnityEngine.UI;

public class RobotDistanceUI : MonoBehaviour
{
    [SerializeField] Text _text;

    private void LateUpdate()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject robot = GameObject.FindWithTag("Robot");

        if (player == null || robot == null)
        {
            _text.text = "Robot Knight is ??? units away from you.";
            return;
        }

        float distance = Vector3.Distance(player.transform.position, robot.transform.position);
        _text.text = $"Robot Knight is {distance} units away from you.";
    }
}
