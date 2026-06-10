using NaughtyAttributes;
using UnityEngine;

public class DebugBlockingSelector : MonoBehaviour
{
	public WalkableRecorder.TileSetup tile;

	public CityData.BlockingDirection dir;

	public MeshRenderer rend;

	public bool blocked;

	public WalkableRecorder recorder;

	public Vector2 offset;

	public void Setup(WalkableRecorder.TileSetup newTile, CityData.BlockingDirection newDir, WalkableRecorder newRecorder, Vector2 newOffset)
	{
	}

	[Button("Set Blocked", EButtonEnableMode.Always)]
	public void SetB()
	{
	}

	[Button("Set Unblocked", EButtonEnableMode.Always)]
	public void SetUB()
	{
	}

	private void SetBlocked(bool val)
	{
	}
}
