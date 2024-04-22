using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageUploader : MonoBehaviour
{
    public GameObject invertedSpherePrefab;
    public Transform spawnPoint;
    public float separationDistance = 2f;
    public float gapBetweenImages = 10f; 
    public Button uploadButton;
    public Text statusText;
    public Vector3 cameraOffset = new Vector3(0f, 1.5f, 0f); 
    public GameObject cameraPrefab;

    public RawImage imageDisplayPrefab; 
    public Transform imageDisplayContainer; 

    private List<Texture2D> uploadedTextures = new List<Texture2D>();
    private List<GameObject> instantiatedSpheres = new List<GameObject>();
    private List<RawImage> displayedImages = new List<RawImage>(); 

    private void Start()
    {
        uploadButton.onClick.AddListener(UploadImage);
    }

    private void UploadImage()
    {
       
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                
                Texture2D texture = NativeGallery.LoadImageAtPath(path, -1);
                if (texture != null)
                {
                    uploadedTextures.Add(texture);

                    
                    InstantiateSphereForTexture(texture);


                    DisplayImage(texture);
                    statusText.text = "Images uploaded: " + uploadedTextures.Count;
                }
                else
                {
                    statusText.text = "Failed to load texture!";
                }
            }
        }, "Select a PNG image");

        Debug.Log("Permission result: " + permission);
    }

    private void InstantiateSphereForTexture(Texture2D texture)
    {
        
        GameObject sphere = Instantiate(invertedSpherePrefab, spawnPoint.position + Vector3.right * (uploadedTextures.Count - 1) * separationDistance, Quaternion.identity);
        Renderer sphereRenderer = sphere.GetComponent<Renderer>();
        if (sphereRenderer != null)
        {
            Material material = new Material(sphereRenderer.material);
            material.mainTexture = texture;
            sphereRenderer.material = material;

          
            if (instantiatedSpheres.Count == 0 && cameraPrefab != null)
            {
                
                GameObject cameraObj = Instantiate(cameraPrefab, sphere.transform);
                cameraObj.transform.localPosition = cameraOffset;
            }

          
            instantiatedSpheres.Add(sphere);
        }
    }

    private void DisplayImage(Texture2D texture)
    { 
       
        RawImage imageDisplay = Instantiate(imageDisplayPrefab, imageDisplayContainer);

     
        Vector3 displayPosition = imageDisplay.transform.localPosition;
        displayPosition.x = displayedImages.Count * (imageDisplayPrefab.rectTransform.rect.width + gapBetweenImages);
        imageDisplay.transform.localPosition = displayPosition;

        imageDisplay.texture = texture;
        displayedImages.Add(imageDisplay);
    }
}
