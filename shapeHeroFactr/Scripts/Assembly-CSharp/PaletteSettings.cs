using UnityEngine;

public class PaletteSettings : ScriptableObject
{
	[Header("初期表示カテゴリ")]
	public ePaletteCategory defaultCategory;

	[Header("パレットに表示する装置の最大数")]
	public int paletteItemCountMax;

	[Header("履歴タブのデフォルトプリセット")]
	public eMachine[] defaultPreset;

	[Header("画面左下の設備詳細に表示する[効果のある設備]一覧")]
	public eMachine[] usableMachines;

	[Header("[効果のある設備]一覧を常時表示するか")]
	public bool alwaysVisibleUsableMachines;
}
