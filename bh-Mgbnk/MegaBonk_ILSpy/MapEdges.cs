using UnityEngine;

public class MapEdges : MonoBehaviour
{
	public MeshRenderer edgeBot;

	public MeshRenderer edgeTop;

	public unsafe void Set(Vector3 worldCenter, Vector3 worldSize, StageData stageData)
	{
		//IL_0091: Expected O, but got Ref
		//IL_00b7: Expected O, but got Ref
		//IL_00de: Expected O, but got Ref
		//IL_012b: Expected O, but got Ref
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = edgeBot.gameObject;
		gameObject2.SetActive(value: true);
		GameObject gameObject3 = edgeTop.gameObject;
		gameObject3.SetActive(value: true);
		Transform transform = edgeBot.transform;
		float num = default(float);
		transform.position = (Vector3)(&num);
		Transform transform2 = edgeTop.transform;
		transform2.position = (Vector3)(&num);
		Transform transform3 = edgeBot.transform;
		transform3.localScale = (Vector3)(&num);
		Transform transform4 = edgeTop.transform;
		Vector3 localScale = transform4.localScale;
		Transform transform5 = edgeTop.transform;
		transform5.localScale = (Vector3)(&num);
		((Renderer)edgeBot).SetMaterial(stageData.triplanarMaterial);
		((Renderer)edgeTop).SetMaterial(stageData.triplanarMaterial);
	}
}
