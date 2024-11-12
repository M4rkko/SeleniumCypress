describe('SwagLabs - Add to Cart and Checkout', () => {
  const testUrl = 'https://www.saucedemo.com';

  beforeEach(() => {
    cy.visit(testUrl, { timeout: 100000 }); // Increase timeout to handle slower loads
    cy.clearCookies();
    cy.clearLocalStorage();
  });

  it('401?', () => {
    cy.get('#user-name').type('standard_user');
    cy.get('#password').type('secret_sauce');
    cy.get('#login-button').click();
    cy.get('#shopping_cart_container').should('be.visible');

    // Add items to the cart
    cy.get('#add-to-cart-sauce-labs-backpack').click();
    cy.get('#add-to-cart-sauce-labs-bike-light').click();

    // Go to the cart and start checkout
    cy.get('#shopping_cart_container').click();
    cy.get('#checkout').click();

    // Fill in checkout information
    cy.get('#first-name').type('John');
    cy.get('#last-name').type('Doe');
    cy.get('#postal-code').type('12345');
    cy.get('#continue').click();

    // Complete the purchase
    cy.get('#finish').click();

    // Verify purchase completion
    cy.contains('Thank you for your order').should('be.visible');
  });
});
