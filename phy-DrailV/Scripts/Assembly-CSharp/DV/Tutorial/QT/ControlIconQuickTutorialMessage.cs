using DV.CabControls;
using DV.Interaction;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class ControlIconQuickTutorialMessage : AQuickTutorialMessage
	{
		public string controlName;

		public string controlDescription;

		public int spriteIndex;

		public ControlIconQuickTutorialMessage(string controlName, string controlDescription, int spriteIndex)
			: this(controlName, controlDescription)
		{
			this.spriteIndex = spriteIndex;
		}

		public ControlIconQuickTutorialMessage(string controlName, string controlDescription)
		{
			this.controlName = controlName;
			this.controlDescription = controlDescription;
		}

		public string Format(QTVerb verb)
		{
			return $"<line-height=0><color={AQuickTutorialStep.GetVerbColor(verb)}><align=\"right\"><sprite=\"quick_tutorial\" index={spriteIndex} tint=1></align>\n" + "<align=\"left\"><margin-right=70><line-height=1.1em>" + AQuickTutorialStep.GetVerbLocalizedString(verb) + "</color>\n<margin-right=70>" + controlName + "</align><line-height=1.4em>\n<line-height=1em>\n<margin-right=0><align=\"left\"><size=75%>" + controlDescription + "</size></align>\n";
		}

		public ControlIconQuickTutorialMessage WithSprite(TrainCar loco, Behaviour target, QTSemantic semantic)
		{
			if (object.Equals(QTSemantic.Look, semantic) || object.Equals(QTSemantic.Monitor, semantic))
			{
				spriteIndex = 2;
				return this;
			}
			if ((object)target != null)
			{
				if (!(target is RotaryBase rotaryBase))
				{
					if (!(target is ToggleSwitchBase))
					{
						if (!(target is ButtonBase))
						{
							if (!(target is WheelBase))
							{
								if (!(target is PullerBase))
								{
									if (!(target is LeverBase))
									{
										if (target is GizmoBase)
										{
											spriteIndex = 3;
										}
									}
									else
									{
										spriteIndex = 4;
									}
								}
								else
								{
									spriteIndex = 3;
								}
							}
							else
							{
								spriteIndex = 6;
							}
						}
						else
						{
							spriteIndex = 0;
						}
					}
					else
					{
						spriteIndex = 1;
					}
				}
				else if (rotaryBase.Spec.handPosesOverride.grabPose == HandPose.Valve)
				{
					spriteIndex = 7;
				}
				else
				{
					spriteIndex = 5;
				}
			}
			return this;
		}
	}
}
