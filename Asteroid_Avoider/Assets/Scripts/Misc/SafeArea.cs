using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private RectTransform rect;
    private Rect safeArea;

    Vector2 minAnchor, maxAnchor;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        safeArea = Screen.safeArea;

        minAnchor = safeArea.position;
        maxAnchor = safeArea.size + minAnchor;

        minAnchor.x /= Screen.width;
        maxAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        minAnchor.y /= Screen.height;

        rect.anchorMin = minAnchor;
        rect.anchorMax = maxAnchor;
    }
}
