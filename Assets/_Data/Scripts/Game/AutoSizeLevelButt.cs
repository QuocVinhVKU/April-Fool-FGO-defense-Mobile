using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(GridLayoutGroup))]
public class AutoSizeLevelButt : MonoBehaviour
{
    private GridLayoutGroup gridLayoutGroup;
    private RectTransform rectTransform;

    [SerializeField]
    private int columns = 5;

    private void Awake()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        CalculateCellSize();
    }

    private void CalculateCellSize()
    {
        float cellWidth = (rectTransform.rect.width - gridLayoutGroup.spacing.x * (columns - 1)) / columns;
        //float cellHeight = (rectTransform.rect.height - gridLayoutGroup.spacing.y * (gridLayoutGroup.constraintCount - 1)) / gridLayoutGroup.constraintCount;
        float cellHeight = cellWidth;
        gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
    }
}
