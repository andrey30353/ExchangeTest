using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ExchangeNews : MonoBehaviour
{  
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private Transform _itemsContent;

    private ExchangeItem[] _items;

    private int _itemsOnPage = 6;
    private float _scrollDelta;

    private void Start()
    {
        _items = _itemsContent.GetComponentsInChildren<ExchangeItem>(true);

        var jsonText = Resources.Load<TextAsset>("Json/Response");       
        var itemsData = JsonHelper.FromJson<ExchangeItemData>(jsonText.ToString());

        Assert.IsTrue(_items.Length >= itemsData.Length);
        for (int i = 0; i < _items.Length; i++)
        {
            if(i < itemsData.Length)
            {
                _items[i].Show(true);
                _items[i].UpdateUI(itemsData[i]);
            }
            else
            {
                _items[i].Show(false);
            }
        }

        var pages = _items.Length / _itemsOnPage;       
        _scrollDelta = 1f / pages;
    }

    public void NextPage()
    {       
        var nextPosition = Mathf.Clamp01(_scrollRect.horizontalNormalizedPosition + _scrollDelta);       
        _scrollRect.horizontalNormalizedPosition = nextPosition; 
    }

    public void PrevPage()
    {
        var nextPosition = Mathf.Clamp01(_scrollRect.horizontalNormalizedPosition - _scrollDelta);
        _scrollRect.horizontalNormalizedPosition = nextPosition;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
