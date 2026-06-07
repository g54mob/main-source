using Assets.Scripts.Character;
using Assets.Scripts.Character.Suit;
using UnityEngine;

namespace Assets.Scripts.Menu.MainMenu
{
	public class MenuCharacterLoadScript : MonoBehaviour
	{
		[SerializeField]
		private CharacterSuitScript _characterSuitScript;

		protected void Awake()
		{
			if ((object)_characterSuitScript == null)
			{
				_characterSuitScript = GetComponentInChildren<CharacterSuitScript>();
			}
			if (_characterSuitScript == null)
			{
				Debug.LogWarning("Can't find menu character to replace it.", this);
				return;
			}
			CharacterManager.Instance.LoadCharacterData();
			_characterSuitScript = CharacterManager.Instance.SwapCharacterSuit(_characterSuitScript, CharacterManager.Instance.SelectedCharacter.Name, CharacterManager.Instance.SelectedSuit.Name, CharacterManager.Instance.SelectedConfig);
			SkinnedMeshRenderer skinnedMeshRenderer = _characterSuitScript.transform.Find("geo_mid_grp/head_geo_mid")?.GetComponent<SkinnedMeshRenderer>();
			skinnedMeshRenderer = skinnedMeshRenderer ?? _characterSuitScript.transform.Find("body_geo_grp/geo_mid_grp/head_geo_mid")?.GetComponent<SkinnedMeshRenderer>();
			if (skinnedMeshRenderer != null)
			{
				skinnedMeshRenderer.SetBlendShapeWeight(0, 35f);
				skinnedMeshRenderer.SetBlendShapeWeight(1, Random.Range(40, 60));
			}
		}
	}
}
