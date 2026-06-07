using UnityEngine;

public class CutterLineVFXScript : MonoBehaviour
{
	[SerializeField]
	private Material _LaserMat;

	[SerializeField]
	private float _laserPos;

	[SerializeField]
	private float _switchingLine;

	[SerializeField]
	private float _PanningGlow;

	private void OnEnable()
	{
		_laserPos = 0f;
		_switchingLine = 0f;
		_PanningGlow = 1f;
		_LaserMat.SetFloat("_Panning", _PanningGlow);
		_LaserMat.SetFloat("_LaserAppear", _laserPos);
		_LaserMat.SetFloat("_IsCutting", _switchingLine);
	}

	private void Update()
	{
		_laserPos = base.gameObject.GetComponent<Animator>().GetFloat("LaserMovement");
		_switchingLine = base.gameObject.GetComponent<Animator>().GetFloat("Switch");
		_PanningGlow = base.gameObject.GetComponent<Animator>().GetFloat("Explode");
		_LaserMat.SetFloat("_Panning", _PanningGlow);
		_LaserMat.SetFloat("_LaserAppear", _laserPos);
		_LaserMat.SetFloat("_IsCutting", _switchingLine);
	}

	private void OnDisable()
	{
		_laserPos = 0f;
		_switchingLine = 0f;
		_PanningGlow = 1f;
		_LaserMat.SetFloat("_Panning", _PanningGlow);
		_LaserMat.SetFloat("_LaserAppear", _laserPos);
		_LaserMat.SetFloat("_IsCutting", _switchingLine);
	}
}
