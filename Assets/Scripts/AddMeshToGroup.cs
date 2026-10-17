using UnityEngine;

public class AddMeshColliders : MonoBehaviour
{
    [ContextMenu("Add Mesh Colliders To Children")]
    void AddColliders()
    {
        MeshFilter[] meshes =
            GetComponentsInChildren<MeshFilter>();

        foreach (MeshFilter mesh in meshes)
        {
            if (mesh.GetComponent<Collider>() == null)
            {
                mesh.gameObject.AddComponent<MeshCollider>();
            }
        }

        Debug.Log("Finished adding Mesh Colliders!");
    }
}