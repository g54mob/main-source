using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySizeRandom : EnemyController
{
	private MultiTargetTween _onEnterTween;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_012b: Expected O, but got I4
		//IL_013d: Expected O, but got F4
		//IL_0066: Expected I, but got O
		//IL_00c6: Expected O, but got I4
		//IL_0089->IL0089: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		object obj = Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.2f;
		float num2 = num * 0.5f;
		if (_onEnterTween != null)
		{
			_onEnterTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			bool flag = obj3 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween onEnterTween = Tweens.Add(tweenConfig);
		_onEnterTween = onEnterTween;
		_hp = (_maxHp = num2 * _maxHp);
	}
}
