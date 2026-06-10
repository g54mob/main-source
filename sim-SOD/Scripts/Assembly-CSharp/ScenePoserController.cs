using UnityEngine;

public class ScenePoserController : MonoBehaviour
{
	[Header("Components")]
	public CitizenOutfitController outfitController;

	[Header("State")]
	public Human human;

	public NewNode node;

	public ClothesPreset.OutfitCategory outfit;

	public GameObject spawnedLeft;

	public GameObject spawnedRight;

	public void SetupCitizen(SceneRecorder.ActorCapture newCapture)
	{
	}
}
