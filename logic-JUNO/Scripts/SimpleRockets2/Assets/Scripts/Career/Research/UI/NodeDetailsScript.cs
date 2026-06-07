using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Career.Research.UI
{
	public class NodeDetailsScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _confirmGroup;

		[SerializeField]
		private TextMeshPro _description;

		[SerializeField]
		private Transform _descriptionCube;

		[SerializeField]
		private GameObject _detailTemplate;

		private ItemBlockScript _item;

		private NodeScript _node;

		private Transform _partContainer;

		[SerializeField]
		private ItemBlockScript _researchButton;

		[SerializeField]
		private BlockScript _researchCancel;

		[SerializeField]
		private BlockScript _researchConfirm;

		private TechTreeUIScript _techTreeUI;

		[SerializeField]
		private BlockScript _unavailableMessage;

		public void Close()
		{
			base.gameObject.SetActive(value: false);
			Object.Destroy(base.gameObject);
		}

		public void ShowDetails(NodeScript node, TechTreeUIScript techTreeUI)
		{
			_techTreeUI = techTreeUI;
			_node = node;
			base.transform.position = node.transform.position + Vector3.forward * 0.5f;
			List<BlockScript> list = new List<BlockScript>();
			if (!node.TechNode.Researched)
			{
				string text = node.CheckIfAvailable();
				if (text == null)
				{
					_researchButton.Initialize(node, null);
					_researchButton.SetText($"UNLOCK\n<size=75%>{node.TechNode.Cost} TECH POINTS</size>");
					list.Add(_researchButton);
				}
				else
				{
					_researchButton.gameObject.SetActive(value: false);
					_unavailableMessage.gameObject.SetActive(value: true);
					_unavailableMessage.SetText(text);
					list.Add(_unavailableMessage);
				}
			}
			else
			{
				_researchButton.gameObject.SetActive(value: false);
			}
			foreach (TechItemValue item in node.TechNode.Items.Reverse())
			{
				if (item.Visible)
				{
					if (!string.IsNullOrWhiteSpace(item.DisplayString))
					{
						GameObject obj = Object.Instantiate(_detailTemplate, base.transform);
						obj.gameObject.SetActive(value: true);
						ItemBlockScript component = obj.gameObject.GetComponent<ItemBlockScript>();
						component.Initialize(node, item);
						list.Insert(0, component);
					}
					else
					{
						Debug.LogWarning(item.TechItem.Id + " is missing a display string and has been hidden.");
					}
				}
			}
			Vector3 vector = Vector3.forward * 1.5f;
			Vector3 endValue = vector + Vector3.forward * (1.5f * (float)(list.Count - 1));
			float num = 0f;
			foreach (BlockScript item2 in list)
			{
				BlockScript block = item2;
				block.transform.DOLocalMove(endValue, 0.1f).SetDelay(num).SetEase(Ease.OutSine)
					.OnComplete(delegate
					{
						SubscribeBlock(block);
					});
				num += 0.1f;
				block.transform.localPosition = -Vector3.forward * 1f;
				endValue -= Vector3.forward * 1.5f;
			}
			_researchButton.Clicked += delegate
			{
				_researchButton.gameObject.SetActive(value: false);
				_confirmGroup.gameObject.SetActive(value: true);
			};
			_researchCancel.Clicked += delegate
			{
				_researchButton.gameObject.SetActive(value: true);
				_confirmGroup.gameObject.SetActive(value: false);
			};
			_researchConfirm.Clicked += delegate
			{
				_confirmGroup.gameObject.SetActive(value: false);
				_techTreeUI.OnNodeResearched(_node);
				Close();
			};
			SubscribeBlock(_researchConfirm);
			SubscribeBlock(_researchCancel);
			_confirmGroup.gameObject.SetActive(value: false);
			_confirmGroup.transform.localPosition = vector;
		}

		private void HideItemDetails()
		{
			_description.transform.parent.gameObject.SetActive(value: false);
			if (_partContainer != null)
			{
				Object.Destroy(_partContainer.gameObject);
				_partContainer = null;
			}
			_item = null;
		}

		private void ShowItemDetails(ItemBlockScript item)
		{
			if (!(_item != item))
			{
				return;
			}
			HideItemDetails();
			_item = item;
			Transform parent = _description.transform.parent;
			parent.gameObject.SetActive(value: true);
			parent.localPosition = item.transform.localPosition + new Vector3(-1.5f, 0f, 0f);
			_description.text = item.Item.TechItem.Description;
			_description.ForceMeshUpdate();
			float num = Mathf.Max(1f, _description.textBounds.size.y + 0.5f);
			_descriptionCube.transform.DOScaleZ(num, 0.1f);
			float num2 = num / 2f + 0.5f;
			if (parent.position.y < num2)
			{
				Vector3 position = parent.position;
				position.y = num2;
				parent.position = position;
			}
			if (item.Item.TechItem.Id.StartsWith("Part."))
			{
				string designerPartName = item.Item.TechItem.Id.Substring("Part.".Length);
				_partContainer = _techTreeUI.PartLoader.LoadDesignerPart(designerPartName, item.transform.position + Vector3.right * 6.75f, 3f * item.Item.PartScale);
				float angle = 0f;
				DOTween.To(() => angle, delegate(float x)
				{
					angle = x;
					_partContainer.localRotation = Quaternion.Euler(0f, angle, 0f) * Quaternion.Euler(item.Item.PartRotation);
				}, angle + 360f, 10f).SetLoops(-1).SetEase(Ease.Linear);
			}
		}

		private void SubscribeBlock(BlockScript block)
		{
			ItemBlockScript item = block as ItemBlockScript;
			block.BeginHover += delegate(BlockScript b)
			{
				b.transform.DOScaleY(0.2f, 0.1f);
				if (item?.Item != null)
				{
					ShowItemDetails(item);
				}
			};
			block.EndHover += delegate(BlockScript b)
			{
				b.transform.DOScaleY(0.1f, 0.1f);
				if (item?.Item != null)
				{
					HideItemDetails();
				}
			};
		}
	}
}
