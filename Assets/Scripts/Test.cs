using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{  
    private void Start()
    {
        var array = new ExchangeItemData[]
        {
            new ExchangeItemData { ItemImageName = "Butter", ItemName = "Масло", ItemCount = 1, ItemPrice = 46,  
                PlayerImageId = 1, PlayerName = "Влад", PlayerLevel = 17 },
            new ExchangeItemData { ItemImageName = "Corn", ItemName = "Кукуруза", ItemCount = 2, ItemPrice = 13,
                PlayerImageId = 2, PlayerName = "Странный", PlayerLevel = 22 },
            new ExchangeItemData { ItemImageName = "Mushrooms", ItemName = "Грибы", ItemCount = 3, ItemPrice = 77,
                PlayerImageId = 3, PlayerName = "Миша", PlayerLevel = 52 },
             new ExchangeItemData { ItemImageName = "Wheat", ItemName = "Пшеница", ItemCount = 4, ItemPrice = 15,
                PlayerImageId = 4, PlayerName = "Филипп", PlayerLevel = 10 },

             new ExchangeItemData { ItemImageName = "Butter", ItemName = "Масло", ItemCount = 5, ItemPrice = 66,
                PlayerImageId = 5, PlayerName = "фыва", PlayerLevel = 13 },
             new ExchangeItemData { ItemImageName = "Corn", ItemName = "Кукуруза", ItemCount = 10, ItemPrice = 85,
                PlayerImageId = 6, PlayerName = "ку", PlayerLevel = 10 },
             new ExchangeItemData { ItemImageName = "Mushrooms", ItemName = "Грибы", ItemCount = 7, ItemPrice = 35,
                PlayerImageId = 7, PlayerName = "Алфы", PlayerLevel = 9 },
             new ExchangeItemData { ItemImageName = "Wheat", ItemName = "Пшеница", ItemCount = 8, ItemPrice = 10,
                PlayerImageId = 8, PlayerName = "Wheat", PlayerLevel = 8 },
        };        

        var json = JsonHelper.ToJson(array, true);
        Debug.Log(json);
    }
}
