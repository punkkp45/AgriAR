using UnityEngine;

public class GrowthUIController : MonoBehaviour
{
    private GrowthStageController currentGrowthController;

    private GrowthStageController GetController()
    {
        if (currentGrowthController == null)
        {
            currentGrowthController =
                FindFirstObjectByType<GrowthStageController>();
        }

        return currentGrowthController;
    }

    public void NextStage()
    {
        GrowthStageController controller = GetController();

        if (controller != null)
        {
            Debug.Log("Growth Controller FOUND!");
            controller.NextStage();
        }
        else
        {
            Debug.LogError("Growth Controller NOT FOUND!");
        }
    }

    public void PreviousStage()
    {
        GrowthStageController controller = GetController();

        if (controller != null)
        {
            Debug.Log("Growth Controller FOUND!");
            controller.PreviousStage();
        }
        else
        {
            Debug.LogError("Growth Controller NOT FOUND!");
        }
    }
}