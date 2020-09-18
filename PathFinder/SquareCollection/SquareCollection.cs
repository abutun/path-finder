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
    public class SquareCollection : CollectionBase
    {
        public SquareCollection()
        {
        }

        public Square Add(Square item)
        {
            base.InnerList.Add(item);

            return item;
        }

        public void Remove(Square item)
        {
            base.InnerList.Remove(item);
        }

        public bool Contains(Square currentItem)
        {
            bool res = false;

            foreach (Square itm in this.InnerList)
            {
                if (itm.X == currentItem.X && itm.Y == currentItem.Y)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

        public Square this[int index]
        {
            get
            {
                return (Square)base.InnerList[index];
            }
            set
            {
                this.InnerList[index] = value;
            }
        }

        public void AddRange(Square[] item)
        {
            base.InnerList.AddRange(item);
        }

        public Square[] GetValues()
        {
            Square[] item = new Square[this.InnerList.Count];

            this.InnerList.CopyTo(0, item, 0, this.InnerList.Count);

            return item;
        }

        protected override void OnInsert(int index, object value)
        {
            base.OnInsert(index, value);
        }
    }
}
