using UnityEngine;
using TMPro;

public class InfoPanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject infoPanel;

    [SerializeField]
    private TMP_Text infoText;

    private int currentStage = 0;

    public void OpenPanel()
    {
        UpdateInformation();
        infoPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        infoPanel.SetActive(false);
    }

    public void SetStage(int stage)
    {
        currentStage = stage;
    }

    private void UpdateInformation()
    {
        if (currentStage == 0)
        {
            infoText.text =
                "WHEAT - EARLY STAGE\n\n" +
                "Stage: Germination & Seedling\n\n" +
                "The seed germinates and the first leaves emerge.\n\n" +
                "Water: Regular but controlled moisture\n" +
                "Soil: Well-drained loamy soil\n" +
                "Temperature: 15°C - 25°C\n\n" +
                "Focus: Maintain soil moisture and healthy growth.";
        }
        else if (currentStage == 1)
        {
            infoText.text =
                "WHEAT - GROWING STAGE\n\n" +
                "Stage: Vegetative Growth\n\n" +
                "The plant develops leaves and increases in height.\n\n" +
                "Water: Moderate irrigation\n" +
                "Soil: Well-drained fertile soil\n" +
                "Temperature: 15°C - 25°C\n\n" +
                "Focus: Adequate water, nutrients and sunlight.";
        }
        else
        {
            infoText.text =
                "WHEAT - MATURE STAGE\n\n" +
                "Stage: Grain Development & Maturity\n\n" +
                "The wheat head develops and grains mature.\n\n" +
                "Water: Reduce irrigation near maturity\n" +
                "Temperature: Around 20°C - 25°C\n\n" +
                "Common Diseases:\n" +
                "Rust, Powdery Mildew, Smut\n\n" +
                "Focus: Monitor grain maturity before harvesting.";
        }
    }
}