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
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PathFinder
{
    public class PathManagerCollection : CollectionBase
    {
        public PathManagerCollection()
        {
        }

        public PathManager Add(PathManager item)
        {
            base.InnerList.Add(item);

            return item;
        }

        public void Remove(PathManager item)
        {
            base.InnerList.Remove(item);
        }

        public bool Contains(PathManager currentItem)
        {
            bool res = false;

            if (currentItem != null)
            {
                foreach (PathManager itm in this.InnerList)
                {
                    if (itm.Name == currentItem.Name)
                    {
                        res = true;
                        break;
                    }
                }
            }

            return res;
        }

        public PathManager this[int index]
        {
            get
            {
                return (PathManager)base.InnerList[index];
            }
            set
            {
                this.InnerList[index] = value;
            }
        }

        public void AddRange(PathManager[] item)
        {
            base.InnerList.AddRange(item);
        }

        public PathManager[] GetValues()
        {
            PathManager[] item = new PathManager[this.InnerList.Count];

            this.InnerList.CopyTo(0, item, 0, this.InnerList.Count);

            return item;
        }

        protected override void OnInsert(int index, object value)
        {
            base.OnInsert(index, value);
        }

        public void SortByTotalCost()
        {
            base.InnerList.Sort(((IComparer)new PathManagerComparer1()));
        }

        public void SortByName()
        {
            base.InnerList.Sort(((IComparer)new PathManagerComparer2()));
        }

        public class PathManagerComparer1 : IComparer
        {
            public PathManagerComparer1()
            {
            }

            public int Compare(object x, object y)
            {
                return ((PathManager)x).TotalCost - ((PathManager)y).TotalCost;
            }

            int IComparer.Compare(object x, object y)
            {
                return this.Compare(x, y);
            }
        }

        public class PathManagerComparer2 : IComparer
        {
            public PathManagerComparer2()
            {
            }

            public int Compare(object x, object y)
            {
                PathManager tmpx = (PathManager)x;
                PathManager tmpy = (PathManager)y;

                string xn, yn;

                xn = tmpx.Name;
                yn = tmpy.Name;

                if (xn.Length == yn.Length)
                {
                    int result = 0;

                    for (int i = 0; i < xn.Length; i++)
                    {
                        int xv, yv;

                        xv = int.Parse(xn[i].ToString());
                        yv = int.Parse(yn[i].ToString());

                        if (xv != yv)
                            result = xv - yv;
                    }

                    return result;
                }
                else
                    return tmpy.Name.Length - tmpx.Name.Length;
            }

            int IComparer.Compare(object x, object y)
            {
                return this.Compare(x, y);
            }
        }
    }
}
