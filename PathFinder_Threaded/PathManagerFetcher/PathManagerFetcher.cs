/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*																		*
*	Copyright (C) 2007  Ahmet BUTUN (butun180@hotmail.com)				*
*	http://www.ahmetbutun.net									        *
*																		*
*	This program is free software; you can redistribute it and/or		*
*	modify it under the terms of the GNU General Public License as		*
*	published by the Free Software Foundation; either version 2 of		*
*	the License, or (at your option) any later version.					*
*																		*
*	This program is distributed in the hope that it will be useful,		*
*	but WITHOUT ANY WARRANTY; without even the implied warranty of		*
*	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU	*
*	General Public License for more details.							*
*																		*
*	You should have received a copy of the GNU General Public License	*
*	along with this program; if not, write to the Free Software			*
*	Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.			*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */


using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinder
{
    public class PathManagerFetcher
    {
        PathManager rootPathManager = null;
        PathManager innerPathManager = null;

        public PathManagerFetcher(PathManager parent, PathManager manager)
        {
            this.rootPathManager = parent;
            this.innerPathManager = manager;
        }

        public void Fetch()
        {
            if (this.rootPathManager != null && this.innerPathManager != null)
            {
                ChangeThreadCount(true);

                this.innerPathManager.BeginManagePath();

                this.rootPathManager.SubPathManagers.Add(innerPathManager);
                this.rootPathManager.SubPathManagers.SortByName();

                ChangeThreadCount(false);
            }
        }

        private void ChangeThreadCount(bool increment)
        {
            PathManager tmpManager = innerPathManager;

            while (tmpManager != null)
            {
                if (increment)
                    tmpManager.ThreadCount++;
                else
                    tmpManager.ThreadCount--;

                tmpManager = tmpManager.ParentPathManager;
            }
        }
    }
}
