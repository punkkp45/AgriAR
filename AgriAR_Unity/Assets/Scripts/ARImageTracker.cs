using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.XR.ARFoundation; 
using UnityEngine.XR.ARSubsystems; 
 
public class ARImageTracker : MonoBehaviour 
{ 
    [SerializeField] 
    private ARTrackedImageManager trackedImageManager; 
 
    [SerializeField] 
    private GameObject babyWheatPrefab; 
 
    private readonly Dictionary<TrackableId, GameObject> spawnedObjects = new(); 
 
    private void Awake() 
    { 
        if (trackedImageManager == null) 
        { 
            trackedImageManager = GetComponent<ARTrackedImageManager>(); 
        } 
    } 
 
    private void OnEnable() 
    { 
        if (trackedImageManager != null) 
        { 
            trackedImageManager.trackablesChanged.AddListener(OnTrackedImagesChanged); 
        } 
    } 
 
    private void OnDisable() 
    { 
        if (trackedImageManager != null) 
        { 
            trackedImageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged); 
        } 
    } 
 
    private void OnTrackedImagesChanged( 
        ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs) 
    { 
        // New images detected 
        foreach (ARTrackedImage trackedImage in eventArgs.added) 
        { 
            CreateWheat(trackedImage); 
        } 
 
        // Existing images updated 
        foreach (ARTrackedImage trackedImage in eventArgs.updated) 
        { 
            if (spawnedObjects.TryGetValue( 
                trackedImage.trackableId, 
                out GameObject wheat)) 
            { 
                wheat.SetActive( 
                    trackedImage.trackingState == TrackingState.Tracking 
                ); 
            } 
        } 
 
        // Images removed 
        foreach (KeyValuePair<TrackableId, ARTrackedImage> removedImage 
                 in eventArgs.removed) 
        { 
            if (spawnedObjects.TryGetValue( 
                removedImage.Key, 
                out GameObject wheat)) 
            { 
                Destroy(wheat); 
                spawnedObjects.Remove(removedImage.Key); 
            } 
        } 
    } 
 
    private void CreateWheat(ARTrackedImage trackedImage) 
    { 
        if (babyWheatPrefab == null) 
        { 
            Debug.LogError("Baby Wheat Prefab is not assigned!"); 
            return; 
        } 
 
        if (spawnedObjects.ContainsKey(trackedImage.trackableId)) 
        { 
            return; 
        } 
 
        // Spawn wheat directly on the detected image 
        GameObject wheat = Instantiate( 
            babyWheatPrefab, 
            trackedImage.transform 
        ); 
 
        wheat.transform.localPosition = Vector3.zero; 
        wheat.transform.localRotation = Quaternion.identity; 
 
        spawnedObjects.Add( 
            trackedImage.trackableId, 
            wheat 
        ); 
    } 
} 
