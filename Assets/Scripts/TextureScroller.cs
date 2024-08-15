using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    GameSettings settings;
    MeshRenderer meshRenderer;

    void Awake()
    {
        settings = FindObjectOfType<GameSettings>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float speed = settings.GetGameSpeed() / transform.localScale.x;

        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
