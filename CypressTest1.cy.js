describe('DemoBlaze - Add to Cart and Buy', () => {
  const testUrl = 'https://www.demoblaze.com/index.html';

  beforeEach(() => {
    cy.clearCookies();
    cy.clearLocalStorage();
    cy.visit(testUrl);
  });

  it('should log in, add a product to the cart, complete purchase', () => {
    cy.get('#login2').click();
    cy.wait(500);  

    cy.get('#loginusername').type('3');
    cy.get('#loginpassword').type('3');

    cy.contains('button', 'Log in').click();
    cy.wait(500);  

    cy.get('.list-group a').contains('Laptops').click();
    cy.wait(500); 

    cy.contains('a', 'MacBook Pro').click();
    cy.wait(5000); 

    cy.contains('a', 'Add to cart').click();
    cy.on('window:alert', (text) => {
      expect(text).to.contains('Product added');
    });

    cy.contains('Cart').click();
    cy.wait(500);  

    cy.contains('button', 'Place Order').click();
    cy.wait(500); 

    cy.get('#name').type('Nimi');
    cy.get('#country').type('Riik');
    cy.get('#city').type('Linn');
    cy.get('#card').type('6593756957');
    cy.get('#month').type('06');
    cy.get('#year').type('2023');

    cy.contains('button', 'Purchase').click();
    cy.wait(1000);  

    cy.contains('Thank you for your purchase').should('be.visible');
  });
});
