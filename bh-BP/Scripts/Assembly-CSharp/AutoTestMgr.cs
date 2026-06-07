using MEC;
using UnityEngine;

public class AutoTestMgr : MonoBehaviour
{
	private CoroutineHandle _curTest;

	[NamedArray(typeof(AutotestSetting))]
	public int[] AutotestSettings;

	public static AutoTestMgr I { get; private set; }
}
