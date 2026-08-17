using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game;
using Assets.Scripts.Managers;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
	public ECharacter character;

	public MyPlayer player;

	public MapData testMapData;

	public StageData testStageData;

	private void Awake()
	{
		Testing.isTesting = true;
		CharacterMenu.selectedCharacter = character;
		MapController.TestMap(testMapData, testStageData);
	}

	private unsafe void Start()
	{
		//IL_0030: Expected O, but got Ref
		//IL_0030: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = default(float);
		object obj = default(object);
		player.Spawn((Vector3)(&num), (Vector3)(&obj));
		PlayerCamera instance = PlayerCamera.Instance;
		instance.cameraState = PlayerCamera.ECameraState.Player3rd;
		GameManager.Instance.StartPlaying();
		UiManager instance2 = UiManager.Instance;
		instance2.hud.SetActive(value: true);
	}
}
