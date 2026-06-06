using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

[AddComponentMenu("Flotsam/Debugging/Buildable Animation Debugger")]
[DisallowMultipleComponent]
public class BuildableAnimationDebugger : MonoBehaviour
{
	[Tooltip("Apply the given settings on game start.")]
	[SerializeField]
	private bool _applyOnStart = true;

	[Header("Animator values")]
	[Tooltip("Bools to set for the animator.")]
	[SerializeField]
	private List<StringBool> _bools = new List<StringBool>();

	[Tooltip("Integers to set for the animator.")]
	[SerializeField]
	private List<StringInt> _ints = new List<StringInt>();

	[Tooltip("Floats to set for the animator.")]
	[SerializeField]
	private List<StringFloat> _floats = new List<StringFloat>();

	private Animator _animator;

	private void Start()
	{
		if (_applyOnStart)
		{
			Apply();
		}
	}

	private void Update()
	{
	}

	[ContextMenu("Apply")]
	public void Apply()
	{
		if (_animator == null)
		{
			_animator = GetComponentInChildren<Animator>();
			if (_animator == null)
			{
				Debugger.Warning("No animator component found on this object!");
				return;
			}
		}
		for (int i = 0; i < _bools.Count; i++)
		{
			_animator.SetBool(_bools[i].String, _bools[i].Bool);
		}
		for (int j = 0; j < _ints.Count; j++)
		{
			_animator.SetInteger(_ints[j].String, _ints[j].Int);
		}
		for (int k = 0; k < _floats.Count; k++)
		{
			_animator.SetFloat(_floats[k].String, _floats[k].Float);
		}
	}
}
