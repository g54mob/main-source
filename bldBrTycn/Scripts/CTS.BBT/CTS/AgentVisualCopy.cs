using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class AgentVisualCopy : MonoSingleton<AgentVisualCopy>
	{
		[SerializeField]
		private GameObject _visualF;

		[SerializeField]
		private GameObject _visualM;

		[SerializeField]
		private SkinnedMeshRenderer _maleBodyMesh;

		[SerializeField]
		private SkinnedMeshRenderer _femaleBodyMesh;

		[SerializeField]
		private Transform _femaleHeadSlot;

		[SerializeField]
		private Transform _maleHeadSlot;

		[SerializeField]
		private Transform _femalePointOfPhotoCamera;

		[SerializeField]
		private Transform _malePointOfPhotoCamera;

		private Animator _animator;

		private GameObject _currenthead;

		private AgentEyesBlinkControler _agentEyesBlinkControler;

		public void SetVisual(Agent p_agent)
		{
			if (_currenthead != null)
			{
				Object.Destroy(_currenthead);
			}
			if (p_agent.AgentVisualControler.CharacterData.Gender == EGender.Male)
			{
				_visualF.SetActive(value: false);
				_visualM.SetActive(value: true);
				_maleBodyMesh.sharedMesh = p_agent.MeshChanger.SelectedBodyMesh;
				_maleBodyMesh.materials = p_agent.MeshChanger.SelectedMaterials;
				_currenthead = Object.Instantiate(p_agent.MeshChanger.SelectedHeadGO, _maleHeadSlot);
				PhotoCamera.instance.SetParent(_malePointOfPhotoCamera);
			}
			else
			{
				_visualM.SetActive(value: false);
				_visualF.SetActive(value: true);
				_femaleBodyMesh.sharedMesh = p_agent.MeshChanger.SelectedBodyMesh;
				_femaleBodyMesh.materials = p_agent.MeshChanger.SelectedMaterials;
				_currenthead = Object.Instantiate(p_agent.MeshChanger.SelectedHeadGO, _femaleHeadSlot);
				PhotoCamera.instance.SetParent(_femalePointOfPhotoCamera);
			}
			_agentEyesBlinkControler.SetSkinnedMeshRenderer = _currenthead.GetComponentInChildren<SkinnedMeshRenderer>();
			AssingLayer(_currenthead, 26);
			_animator.avatar = p_agent.MeshChanger.SelectedAvatar;
		}

		protected override void OnSingletonDestroy()
		{
		}

		protected override void SingletonAwake()
		{
			_animator = GetComponent<Animator>();
			_agentEyesBlinkControler = GetComponent<AgentEyesBlinkControler>();
		}

		public static void AssingLayer(GameObject o, int _layerIdx, bool _recursive = true)
		{
			o.layer = _layerIdx;
			if (_recursive)
			{
				for (int i = 0; i < o.transform.childCount; i++)
				{
					AssingLayer(o.transform.GetChild(i).gameObject, _layerIdx, _recursive);
				}
			}
		}
	}
}
