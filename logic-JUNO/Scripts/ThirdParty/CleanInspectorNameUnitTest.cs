using UnityEngine;

public class CleanInspectorNameUnitTest : MonoBehaviour
{
	[CleanInspectorName]
	public string _strCrazyTextName;

	[CleanInspectorName("Genifer garner")]
	public float _fAliasedName;

	[CleanInspectorName]
	public bool _bFoldoutValue;

	[CleanInspectorName("", "_bFoldoutValue")]
	public float _fValueToHide1;

	[CleanInspectorName("", "_bFoldoutValue", null, "Test Tool Tip")]
	public float _fValueToHide2;

	[CleanInspectorName("", "_bFoldoutValue", null, "Test Tool Tip", 1)]
	public string _bNestedFoldoutMaster0 = "";

	[CleanInspectorName("", "_bNestedFoldoutMaster0", "True")]
	public int _iNestedFoldOut0;

	[CleanInspectorName]
	public int _iNonHideValue;

	[CleanInspectorName("", "_bFoldoutValue", null, "Test Tool Tip", 2, 1f, 0f, 0f)]
	public string _strValueToHide3;

	[CleanInspectorName("", "_bFoldoutValue")]
	public bool _bNestedFoldoutMaster;

	[CleanInspectorName("", "_bNestedFoldoutMaster")]
	public int _iNestedFoldOut;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
