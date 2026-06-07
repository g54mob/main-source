using UnityEngine;

public class StaffrollSettings : ScriptableObject
{
	[Header("スタッフロールが流れるスピード")]
	public float moveSpeed;

	[Header("スタッフロールの1ライン(lineFeed)の太さ")]
	public float lineHeight;

	[Header("スタッフロールが動き始めるまでの時間")]
	public float startWait;

	[Header("スタッフロールが完全に終了してダイアログが自動で閉じるまでの時間")]
	public float finishWait;

	[Space(16f)]
	[Header("エンドロールが流れるスピード")]
	public float moveSpeedEndroll;

	[Header("エンドロールの1ライン(lineFeed)の太さ")]
	public float lineHeightEndroll;

	[Header("エンドロールが動き始めるまでの時間")]
	public float startWaitEndroll;

	[Header("エンドロール終了から最後の演出までの時間")]
	public float finishWaitEndroll;

	[Header("最後の演出終了後、ダイアログが閉じるまでの時間")]
	public float finishAnimationWait;
}
