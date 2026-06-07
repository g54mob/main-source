using UnityEngine;

public class ElevatorHighlight : MonoBehaviour
{
	public Material Good;

	public Material Bad;

	public Renderer rend;

	private int lastFloor = -5;

	private void Start()
	{
		base.transform.position = new Vector3(base.transform.position.x, GameSettings.MaxFloor, base.transform.position.z);
		base.transform.localScale = new Vector3(0.5f, GameSettings.MaxFloor * 2 + 4, 0.5f);
	}

	public void UpdateBeam(Furniture Parent, bool force = false)
	{
		if (!(GameSettings.Instance.ActiveFloor != lastFloor || force))
		{
			return;
		}
		if (Parent.Parent.Floor == GameSettings.Instance.ActiveFloor)
		{
			bool flag = Parent.GetConnectedElevator(true) != null || Parent.GetConnectedElevator(false) != null;
			rend.sharedMaterial = (flag ? Good : Bad);
			return;
		}
		Furniture furniture = Parent;
		while (furniture != null && furniture.Parent != null && furniture.Parent.Floor != GameSettings.Instance.ActiveFloor)
		{
			furniture = furniture.GetConnectedElevator(furniture.Parent.Floor < GameSettings.Instance.ActiveFloor);
		}
		rend.sharedMaterial = ((furniture == null) ? Bad : Good);
		lastFloor = GameSettings.Instance.ActiveFloor;
	}
}
