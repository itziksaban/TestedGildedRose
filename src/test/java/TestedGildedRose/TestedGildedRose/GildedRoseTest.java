package TestedGildedRose.TestedGildedRose;

import org.junit.Test;

import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.assertThat;

public class GildedRoseTest {

    public static final String SULFURAS_NAME = "Sulfuras, Hand of Ragnaros";
    public static final String BACKSTAGE_PASS_NAME = "Backstage passes to a TAFKAL80ETC concert";
    public static final String AGED_BRIE_NAME = "Aged Brie";

    @Test
    public void should_decrease_quality_by_one() {
        Item item = newItem("", 0, 1);
        updateItems(item);
        assertThat(item.quality, is(0));
    }

    @Test
    public void should_not_decrease_quality_if_sulfuras() {
        Item item = newItem(SULFURAS_NAME, 0, 1);
        updateItems(item);
        assertThat(item.quality, is(1));
    }

    @Test
    public void should_not_decrease_quality_if_already_zero() {
        Item item = newItem("", 0, 0);
        updateItems(item);
        assertThat(item.quality, is(0));
    }

    @Test
    public void should_increase_quality_by_two_if_backstage_sellin_is_under_11() {
        Item item = newItem(BACKSTAGE_PASS_NAME, 10, 1);
        updateItems(item);
        assertThat(item.quality, is(3));
    }

    @Test
    public void should_not_increase_quality_over_50_if_backstage_sellin_is_under_11() {
        Item item = newItem(BACKSTAGE_PASS_NAME, 10, 49);
        updateItems(item);
        assertThat(item.quality, is(50));
    }

    @Test
    public void should_increase_quality_by_three_if_backstage_sellin_is_under_6() {
        Item item = newItem(BACKSTAGE_PASS_NAME, 5, 1);
        updateItems(item);
        assertThat(item.quality, is(4));
    }

    @Test
    public void should_not_increase_quality_over_50_if_backstage_sellin_is_under_6() {
        Item item = newItem(BACKSTAGE_PASS_NAME, 5, 49);
        updateItems(item);
        assertThat(item.quality, is(50));
    }
    
    @Test
    public void should_increase_quality_if_aged_brie() {
        Item item = newItem(AGED_BRIE_NAME, 1, 1);
        updateItems(item);
        assertThat(item.quality, is(2));
    }

    @Test
    public void should_not_increase_quality_over_50_if_aged_brie() {
        Item item = newItem(AGED_BRIE_NAME, 1, 50);
        updateItems(item);
        assertThat(item.quality, is(50));
    }
    
    @Test
    public void should_decrease_sellin() {
        Item item = newItem("", 1, 0);
        updateItems(item);
        assertThat(item.sellIn, is(0));
    }

    @Test
    public void should_not_decrease_sellin_if_sulfuras() {
        Item item = newItem(SULFURAS_NAME, 1, 0);
        updateItems(item);
        assertThat(item.sellIn, is(1));
    }
    
    @Test
    public void should_decrease_quality_by_two_if_sellin_negative() {
        Item item = newItem("", 0, 2);
        updateItems(item);
        assertThat(item.quality, is(0));
    }

    @Test
    public void should_decrease_quality_under_zero_if_sellin_negative() {
        Item item = newItem("", 0, 1);
        updateItems(item);
        assertThat(item.quality, is(0));
    }
    
    @Test
    public void should_set_quality_to_zero_if_backstage_sellin_is_negative() {
        Item item = newItem(BACKSTAGE_PASS_NAME, 0, 10);
        updateItems(item);
        assertThat(item.quality, is(0));
    }
    
    @Test
    public void should_increase_quality_by_two_if_brie_sellin_is_negative() {
        Item item = newItem(AGED_BRIE_NAME, 0, 1);
        updateItems(item);
        assertThat(item.quality, is(3));
    }

    @Test
    public void should_not_increase_quality_over_50_if_brie_sellin_is_negative() {
        Item item = newItem(AGED_BRIE_NAME, 0, 49);
        updateItems(item);
        assertThat(item.quality, is(50));
    }

    private Item newItem(String name, int sellIn, int quality) {
        return new Item(name, sellIn, quality);
    }

    private void updateItems(Item... items) {
        new GildedRose(items).updateQuality();
    }

}