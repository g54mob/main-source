using UnityEngine;

[ExecuteInEditMode]
public class SetGlobalShaderVarPlayerPosition : MonoBehaviour
{
	private const string cString_PlayerPosition = "_PlayerPosition";

	private void Update()
	{
		Shader.SetGlobalVector("_PlayerPosition", base.transform.position);
	}
}
