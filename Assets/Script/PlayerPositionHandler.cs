using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{

    [SerializeField] Vector2 playerCurrentPosition;
    [SerializeField] Vector2 currentCheckpointPosition;
    public TransformData playerPositionData;

    void Start()
    {
        
    }

    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
        CheckpointWallActive(col);
    }

    public void CheckpointWallActive(GameObject wall)
    {
        //Debug.Log("name="+ wall.gameObject.transform.GetChild(0).gameObject.name);
        wall.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnTrap()
    {
        ChangePlayerPosition(currentCheckpointPosition);
    }

    private void LoadPosition()
    {
        playerCurrentPosition = playerPositionData.position;
    }

    private void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }

    private void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    } 
}
