using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace XDef
{
	public class XDefSystem:ModSystem
	{
		public override void UpdateUI(GameTime gameTime)
		{
			//if (XDebugger.XDebugger.DebugMode)
			//{
			//	XDebugger.XDebugger.UpdateUI(gameTime);
			//}
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			//if (XDebugger.XDebugger.DebugMode)
			//{
			//	XDebugger.XDebugger.ModifyInterfaceLayers(layers);
			//}
		}
	}
}
