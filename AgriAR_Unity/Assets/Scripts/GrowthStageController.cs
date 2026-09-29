using UnityEngine;

public class GrowthStageController : MonoBehaviour
{
    [SerializeField]
    private GameObject babyWheat;

    [SerializeField]
    private GameObject smallerWheat;

    [SerializeField]
    private GameObject matureWheat;

    private int currentStage = 0;

    private void OnEnable()
    {
        ShowStage(currentStage);
    }

    public void NextStage()
    {
        if (currentStage < 2)
        {
            currentStage++;
            ShowStage(currentStage);
        }
    }

    public void PreviousStage()
    {
        if (currentStage > 0)
        {
            currentStage--;
            ShowStage(currentStage);
        }
    }

    private void ShowStage(int stage)
{
    babyWheat.SetActive(stage == 0);
    smallerWheat.SetActive(stage == 1);
    matureWheat.SetActive(stage == 2);

    InfoPanelController infoPanel =
        FindFirstObjectByType<InfoPanelController>();

    if (infoPanel != null)
    {
        infoPanel.SetStage(stage);
    }
}
}